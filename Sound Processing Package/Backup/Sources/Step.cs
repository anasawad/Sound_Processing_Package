using System;

namespace Garbe.Sound
{
	/// <summary> Calculate the signal with some gain </summary>
	public sealed class Step : SoundObj
	{
		float	_initialValue;
		bool  _already;

		/// <summary> Calculate the signal with some gain </summary>
		/// <param name="i">Value of the gain</param>
		public Step(float i) : base()
		{
			_initialValue = i;
			_already = false;
		}

		/// <summary> Do the signal processing </summary>
		public override void DoProcess()
		{
			if(_already)
				base._output = _initialValue;
			else
			{
				base._output = 0;
				_already= true;
			}
		}
		
		/// <summary> Number of interations expected to do the signal processing </summary>
		public override int Interations
		{
			get{return(0);}
		}


	}
}
