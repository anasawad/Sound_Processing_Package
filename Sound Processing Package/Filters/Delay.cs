using System;

namespace Garbe.Sound
{
    /// <summary> Create a delay of certain sample numbers in the signal </summary>
    public sealed class Delay : SoundObj
    {
        float[] _delayBuffer;
        int _pos;
        int _delay;

        float _temp;

        /// <summary> Create a delay of certain sample numbers in the signal </summary>
        /// <param name="x">Number of samples delayed inthe signal</param>
        public Delay(int x)
            : base()
        {
            if (x == 0)
                _delay = 0;
            else
            {
                _delay = x - 1;
                _delayBuffer = new float[x];
                this.Reset();
            }
        }

        /// <summary> Do the signal processing </summary>
        public override void DoProcess()
        {
            if (_delay == 0)
            {
                base._output = (Input.Output);
            }
            else
            {
                // Retrieve
                _temp = _delayBuffer[_pos];

                // Store
                _delayBuffer[_pos] = Input.Output;
                if (_pos == _delay)
                    _pos = 0;
                else
                    _pos++;

                base._output = (_temp);
            }
        }

        private void Reset()
        {
            for (_pos = 0; _pos <= _delay; _pos++)
                _delayBuffer[_pos] = 0;

            _pos = 0;
        }
        /// <summary> Number of interations expected to do the signal processing </summary>
        public override int Interations
            {
            get { return (base._input.Interations + _delay + 1); }
        }
    }
}
