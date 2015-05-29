using Madeira.Exceptions;
using Madeira.Resources;
using OpenTK;
using OpenTK.Audio.OpenAL;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madeira.Core.Loaders
{
	/// <summary>
	/// Represents the loader for loading sounds.
	/// </summary>
	public class SoundLoader : Loader<Sound>
	{
		/// <summary>
		/// Loads a sound from the specified file.
		/// </summary>
		/// <param name="file">the file</param>
		/// <returns>the sound</returns>
		protected override Sound Load(string file)
		{
			using (BinaryReader binaryReader = new BinaryReader(File.Open(file, FileMode.Open)))
			{
				var signature = new string(binaryReader.ReadChars(4));

				if (signature != "RIFF")
				{
					throw new ResourceException("Sound is not a RIFF file.");
				}

				var chunkSize = binaryReader.ReadInt32();
				var format = new string(binaryReader.ReadChars(4));

				if (format != "WAVE")
				{
					throw new ResourceException("Sound is not a WAVE file.");
				}

				var formatSignature = new string(binaryReader.ReadChars(4));

				if (formatSignature != "fmt ")
				{
					throw new ResourceException("Sound format is not supported.");
				}

				var formatChunkSize = binaryReader.ReadInt32();
				var audioFormat = binaryReader.ReadInt16();
				var channels = binaryReader.ReadInt16();
				var sampleRate = binaryReader.ReadInt32();
				var byteRate = binaryReader.ReadInt32();
				var blockAlign = binaryReader.ReadInt16();
				var bitsPerSample = binaryReader.ReadInt16();

				var dataSignature = new string(binaryReader.ReadChars(4));

				if (dataSignature != "data")
				{
					throw new ResourceException("Sound format is not supported.");
				}

				var data = binaryReader.ReadBytes((int) binaryReader.BaseStream.Length);

				var buffer = AL.GenBuffer();
				var source = AL.GenSource();

				AL.BufferData(buffer, this.GetFormat(channels, bitsPerSample), data, data.Length, sampleRate);
				AL.Source(source, ALSourcei.Buffer, buffer);
				AL.Source(source, ALSourcef.MaxDistance, 1.0F);
				AL.Source(source, ALSourceb.SourceRelative, true);

				return new Sound(source, channels, sampleRate);
			}
		}

		/// <summary>
		/// Returns the format for the specified channels and sample rate.
		/// </summary>
		/// <param name="channels">the channels</param>
		/// <param name="bits">the bits per sample</param>
		/// <returns>the format</returns>
		private ALFormat GetFormat(int channels, int bits)
		{
			switch (channels)
			{
				case 1:
				{
					return bits == 8 ? ALFormat.Mono8 : ALFormat.Mono16;
				}
				case 2:
				{
					return bits == 8 ? ALFormat.Stereo8 : ALFormat.Stereo16;
				}
				default:
				{
					throw new ResourceException("Audio format is not supported.");
				}
			}
		}
	}
}
