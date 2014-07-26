using System;

namespace Garbe.Sound
{
	/// <summary> Basic Implementation of ISoundObj and ISoundControl interfaces </summary>
	public abstract class SoundObj : ISoundObj, ISoundControl
	{
		/// <summary> Store the data the will be used as output signal </summary>
		protected float     _output;
		/// <summary> Store the object the is used as input signal </summary>
		protected SoundObj  _input;

		/// <summary> Basic Implementation of ISoundObj and ISoundControl interfaces </summary>
		public SoundObj()
		{
			_output = 0;
		}

		/// <summary> Get the output Signal </summary>
        public virtual float Output
        {
            get { return (_output); }
        }

		/// <summary> Get or Set the input object </summary>
		public virtual SoundObj Input
		{
			get{return(_input);}
			set{_input = value;}
		}

		/// <summary> Do the signal processing </summary>
		public virtual void DoProcess()
		{
			_output = _input.Output;
		}

		/// <summary> Turns on or off the control of the signal </summary>
		public virtual bool Enable
		{
			get{return(true);}
		}

		/// <summary> Number of interations expected to do the signal processing </summary>
		public virtual int Interations
		{
			get{return(_input.Interations);}
		}

		/// <summary> Gets the sample rate of the signal </summary>
		public virtual uint SampleRate
		{
			get{return(_input.SampleRate);}
		}

		/// <summary> Gets the number of channels of the signal </summary>
		public virtual ushort NumChannels
		{
			get{return(1);}
		}
	}
}
