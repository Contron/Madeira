using Madeira.Core.Visuals;
using Madeira.Maths;
using Madeira.Resources;
using Madeira.Utilities;
using OpenTK;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madeira.Core
{
	/// <summary>
	/// Represents the core game for containing the game window and logic.
	/// </summary>
	public class Game
	{
		/// <summary>
		/// Creates a new game.
		/// </summary>
		/// <param name="name">the name</param>
		/// <param name="width">the width</param>
		/// <param name="height">the height</param>
		/// <param name="icon">the icon</param>
		public Game(string name, int width = 480, int height = 480, System.Drawing.Icon icon = null)
		{
			this.Name = name;
			this.Width = width;
			this.Height = height;
			this.Time = 0;

			this.Input = new Input();
			this.Library = new Library();
			this.Random = new Random();

			this.window = new GameWindow(this.Width, this.Height, GraphicsMode.Default, this.Name)
			{
				VSync = VSyncMode.Adaptive,
				WindowBorder = WindowBorder.Fixed,
				CursorVisible = false,
				Icon = icon
			};
			this.audio = new AudioContext();

			this.state = null;

			this.Initialise();
		}

		/// <summary>
		/// Runs the game.
		/// </summary>
		public void Run()
		{
			Debug.Information("Running game...");

			this.window.Run(60.0);
		}

		/// <summary>
		/// Stops the game.
		/// </summary>
		public void Stop()
		{
			Debug.Information("Stopping game...");

			this.window.Close();
		}

		/// <summary>
		/// Changes the current state.
		/// </summary>
		/// <param name="state">the state</param>
		public void ChangeState(State state)
		{
			Debug.Information("Changing state to {0}...", state.GetType().Name);

			if (this.state != null)
			{
				this.state.Exit();
			}

			this.state = state;
			this.state.Enter();
		}

		private void Prepare()
		{
			Debug.Information("Preparing OpenGL...");

			GL.Enable(EnableCap.AlphaTest);
			GL.Enable(EnableCap.Blend);

			GL.ClearColor(0.3F, 0.3F, 0.6F, 0.0F);
			GL.AlphaFunc(AlphaFunction.Greater, 0F);
			GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
			GL.DepthFunc(DepthFunction.Lequal);
			GL.ShadeModel(ShadingModel.Smooth);
			GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

			Debug.Information("Preparing OpenAL...");

			AL.DistanceModel(ALDistanceModel.LinearDistanceClamped);
			AL.Listener(ALListener3f.Position, 0F, 0F, 0F);
			AL.Listener(ALListener3f.Velocity, 0F, 0F, 0F);
		}

		private void Update()
		{
			if (this.state != null)
			{
				this.state.Update();
			}

			this.Time++;
			this.Input.Update();
		}

		private void Render()
		{
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			if (this.state != null)
			{
				this.state.Render();
			}

			this.window.SwapBuffers();
		}

		private void Initialise()
		{
			Debug.Information("Initialising window...");

			this.window.Load += (sender, eventArgs) => this.Prepare();
			this.window.UpdateFrame += (sender, eventArgs) => this.Update();
			this.window.RenderFrame += (sender, eventArgs) => this.Render();
		}

		/// <summary>
		/// Gets the name of the game.
		/// </summary>
		public string Name
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets the width of the game.
		/// </summary>
		public int Width
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets te height of the game.
		/// </summary>
		public int Height
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets the elapsed time for the game.
		/// </summary>
		public long Time
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets the input handler for the game.
		/// </summary>
		public Input Input
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets the asset library for the game.
		/// </summary>
		public Library Library
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets the random for the game.
		/// </summary>
		public Random Random
		{
			get;
			private set;
		}

		private GameWindow window;
		private AudioContext audio;

		private State state;
	}
}
