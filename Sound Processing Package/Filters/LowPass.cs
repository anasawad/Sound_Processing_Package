using System;

namespace Garbe.Sound
{
	/// <summary> Calculate the signal with a low pass filter </summary>
	public sealed class LowPass : SoundObj
	{
		float	_gain;
		
		/// <summary> Calculate the signal with a low pass filter </summary>
		/// <param name="g">Value of the gain of the low pass filter</param>
		public LowPass(float g) : base()
		{
			_gain = g;
		}

		/// <summary> Do the signal processing </summary>
		public override void DoProcess()
		{
			base._output = (1 - _gain) * base._input.Output + _gain * base._output;
		}
		
		/// <summary> Number of interations expected to do the signal processing </summary>
		public override int Interations
		{
			get{return(base._input.Interations);}
		}


	}
}