using System;

namespace Garbe.Sound
{
	/// <summary> Calculate the signal with some gain </summary>
	public sealed class Gain : SoundObj
	{
		float	_gain;

		/// <summary> Calculate the signal with some gain </summary>
		/// <param name="g">Value of the gain</param>
		public Gain(float g) : base()
		{
			_gain = g;
		}

		/// <summary> Do the signal processing </summary>
		public override void DoProcess()
		{
			base._output = _gain * base._input.Output;
		}
		
		/// <summary> Number of interations expected to do the signal processing </summary>
		public override int Interations
		{
			get{return(base._input.Interations);}
		}


	}
}
