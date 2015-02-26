using Madeira.Maths;
using OpenTK;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madeira.Core
{
	/// <summary>
	/// Represents the input handler to listen for keyboard and mouse events.
	/// </summary>
	public class Input
	{
		/// <summary>
		/// Creates a new input handler.
		/// </summary>
		internal Input()
		{
			this.keyboardState = default(KeyboardState);

			this.mouseState = default(MouseState);
			this.previousMouseState = default(MouseState);
		}

		/// <summary>
		/// Returns if the specified key is down.
		/// </summary>
		/// <param name="key">the key</param>
		/// <returns>if the key is down</returns>
		public bool IsKeyDown(Key key)
		{
			return this.keyboardState.IsKeyDown(key);
		}

		/// <summary>
		/// Returns if the specified mouse button is down.
		/// </summary>
		/// <param name="mouseButton">the mouse button</param>
		/// <returns>if the mouse button is down</returns>
		public bool IsMouseButtonDown(MouseButton mouseButton)
		{
			return this.mouseState.IsButtonDown(mouseButton);
		}

		/// <summary>
		/// Updates the input.
		/// </summary>
		internal void Update()
		{
			this.keyboardState = Keyboard.GetState();

			this.previousMouseState = this.mouseState;
			this.mouseState = Mouse.GetState();
		}

		/// <summary>
		/// Gets the current position of the mouse for the input.
		/// </summary>
		public Point MousePosition
		{
			get
			{
				return new Point(this.mouseState.X, this.mouseState.Y);
			}
		}

		/// <summary>
		/// Gets the current velocity of the mouse for the input.
		/// </summary>
		public Point MouseVelocity
		{
			get
			{
				return new Point(this.mouseState.X - this.previousMouseState.X, this.mouseState.Y - this.previousMouseState.Y);
			}
		}

		private KeyboardState keyboardState;

		private MouseState mouseState;
		private MouseState previousMouseState;
	}
}
