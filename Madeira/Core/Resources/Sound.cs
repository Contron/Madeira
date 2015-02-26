using OpenTK.Audio.OpenAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madeira.Resources
{
	/// <summary>
	/// Represents an OpenAL sound.
	/// </summary>
	public class Sound
	{
		/// <summary>
		/// Creates a new sound.
		/// </summary>
		/// <param name="id">the ID</param>
		/// <param name="channels">the channels</param>
		/// <param name="sampleRate">the sample rate</param>
		internal Sound(int id, int channels, int sampleRate)
		{
			this.ID = id;

			this.Channels = channels;
			this.SampleRate = sampleRate;

			this.looping = false;

			this.balance = 0;
			this.pitch = 1;
			this.gain = 1;
		}

		/// <summary>
		/// Returns a string representation of the sound.
		/// </summary>
		/// <returns>a string representation</returns>
		public override string ToString()
		{
			return string.Format("Sound (ID: {0}, Channels: {1}, Sample Rate: {2})", this.ID, this.Channels, this.SampleRate);
		}

		/// <summary>
		/// Plays the sound.
		/// </summary>
		public void Play()
		{
			//play
			AL.SourcePlay(this.ID);
		}

		/// <summary>
		/// Pauses the sound.
		/// </summary>
		public void Pause()
		{
			//pause
			AL.SourcePause(this.ID);
		}

		/// <summary>
		/// Stops the sound.
		/// </summary>
		public void Stop()
		{
			//stop
			AL.SourceStop(this.ID);
		}

		/// <summary>
		/// Gets the ID of the sound.
		/// </summary>
		public int ID
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets the channels of the sound.
		/// </summary>
		public int Channels
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets the sample rate of the sound.
		/// </summary>
		public int SampleRate
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets or sets if the sound is looping.
		/// </summary>
		public bool Looping
		{
			get
			{
				return this.looping;
			}
			set
			{
				this.looping = value;

				AL.Source(this.ID, ALSourceb.Looping, this.looping);
			}
		}

		/// <summary>
		/// Gets or sets the balance of the sound.
		/// </summary>
		public double Balance
		{
			get
			{
				return this.balance;
			}
			set
			{
				this.balance = value;

				AL.Source(this.ID, ALSource3f.Position, (float) this.balance, (float) 0, (float) 0);
			}
		}

		/// <summary>
		/// Gets or sets te pitch of the sound.
		/// </summary>
		public double Pitch
		{
			get
			{
				return this.pitch;
			}
			set
			{
				this.pitch = value;

				AL.Source(this.ID, ALSourcef.Pitch, (float) this.pitch);
			}
		}

		/// <summary>
		/// Gets or sets the gain of the sound.
		/// </summary>
		public double Gain
		{
			get
			{
				return this.gain;
			}
			set
			{
				this.gain = value;

				AL.Source(this.ID, ALSourcef.Gain, (float) this.gain);
			}
		}

		private bool looping;

		private double balance;
		private double pitch;
		private double gain;
	}
}
