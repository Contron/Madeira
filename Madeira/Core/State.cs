using Madeira.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madeira.Core
{
	/// <summary>
	/// Represents a single state in the game which can indepentently update and render itself.
	/// </summary>
	public abstract class State
	{
		/// <summary>
		/// Creates a new state.
		/// </summary>
		/// <param name="game">the game</param>
		public State(Game game)
		{
			this.Game = game;
		}


		/// <summary>
		/// Enters the state.
		/// </summary>
		public virtual void Enter()
		{

		}

		/// <summary>
		/// Updates the state.
		/// </summary>
		public virtual void Update()
		{

		}

		/// <summary>
		/// Renders the state.
		/// </summary>
		public virtual void Render()
		{

		}

		/// <summary>
		/// Exits the state.
		/// </summary>
		public virtual void Exit()
		{

		}

		/// <summary>
		/// Gets the game for the state.
		/// </summary>
		public Game Game
		{
			get;
			private set;
		}
	}
}
