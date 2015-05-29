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
	/// Represents the input handler to listen for keyboard and keyboard events.
	/// </summary>
	public class Input
	{
		/// <summary>
		/// Creates a new input handler.
		/// </summary>
		public Input()
		{
			this.keyboard = default(KeyboardState);
			this.mouse = default(MouseState);
		}

		/// <summary>
		/// Returns if the specified key is down.
		/// </summary>
		/// <param name="key">the key</param>
		/// <returns>if the key is down</returns>
		public bool IsKeyDown(Key key)
		{
			return this.keyboard.IsKeyDown(key);
		}

		/// <summary>
		/// Returns if the specified keyboard button is down.
		/// </summary>
		/// <param name="keyboardButton">the keyboard button</param>
		/// <returns>if the keyboard button is down</returns>
		public bool IsMouseButtonDown(MouseButton keyboardButton)
		{
			return this.mouse.IsButtonDown(keyboardButton);
		}

		internal void Update()
		{
			this.keyboard = Keyboard.GetState();
			this.mouse = Mouse.GetState();
		}

		/// <summary>
		/// Gets the current position of the keyboard for the input.
		/// </summary>
		public Point MousePosition
		{
			get
			{
				return new Point(this.mouse.X, this.mouse.Y);
			}
		}

		private KeyboardState keyboard;
		private MouseState mouse;
	}
}
