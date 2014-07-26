using System;

namespace Garbe.Sound
{
	/// <summary> Basic implementation of the ISoundControl </summary>
	public abstract class SoundControl : ISoundControl
	{
		/// <summary> SoundControl Constructor </summary>
		public SoundControl()
		{
			
		}

		/// <summary> Do the signal processing </summary>
		public virtual void DoProcess()
		{
			
		}

		/// <summary> Turns on or off the control of the signal </summary>
		public virtual bool Enable
		{
			get{return(true);}
		}

	}
}
