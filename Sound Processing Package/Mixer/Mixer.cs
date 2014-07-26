using System;

namespace Garbe.Sound
{
	/// <summary> Calculate the mixing signal from a collection of source signals </summary>
	public sealed class Mixer : SoundObj
	{
		private ushort      _numChannels;
		private SoundObj[]  _inputs;
		private int			_counter;

		/// <summary> Calculate the mixing signal from a collection of source signals </summary>
		/// <param name="c">Number of channels</param>
		public Mixer(ushort c) : base()
		{
			_numChannels = c;
			_inputs = new SoundObj[c];
		}

		/// <summary> Do the signal processing </summary>
		public override void DoProcess()
		{
			_output = 0;

			for(_counter = 0; _counter < _numChannels; _counter++)
				_output += _inputs[_counter].Output;
		}
		
		/// <summary> Number of interations expected to do the signal processing </summary>
		public override int Interations
		{
			get
			{
				int max = 0;
				for(_counter = 1; _counter < _numChannels; _counter++)
				{
					if(_inputs[_counter - 1].Interations > _inputs[_counter].Interations)
						max = _inputs[_counter - 1].Interations;
					else
						max = _inputs[_counter].Interations;
				}

				return(max);
			}
		}

		/// <summary> Gets the number of channels of the signal </summary>
		public override ushort NumChannels
		{
			get{return(this._numChannels);}
		}

		/// <summary> Gets or Sets the source signals of each channel </summary>
		public SoundObj this[int index]
		{
			get 
			{
				if(index <= _numChannels)
					return(_inputs[index]);
				else
					throw new Exception("Out of Range!!!");
			}
			set 
			{
				if(index <= _numChannels)
					_inputs[index] = value;
				else
					throw new Exception("Out of Range!!!");
			}
		}


	}
}
