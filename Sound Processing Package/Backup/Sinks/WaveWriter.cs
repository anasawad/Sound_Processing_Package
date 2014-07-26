using System;
using System.IO;

namespace Garbe.Sound
{
	/// <summary> Write the samples processed in a wave file </summary>
	public sealed class WaveWriter :SoundObj
	{

		// //////////////////////////////////////////////////////////////////////////////////////////////////
		// Membros da Classe
		// //////////////////////////////////////////////////////////////////////////////////////////////////

		private FileStream     _fs;
		private BinaryWriter   _w;
		private BufferedStream _bs;

		private uint _dataSize;
		private float _gain;

		#region CONSTRUTORES

		// //////////////////////////////////////////////////////////////////////////////////////////////////
		// Construtores
		// //////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary> Write the samples processed in a wave file </summary>
		/// <param name="fileName">Name of the wave file</param>
		/// <param name="numChannels">Number of channels of the wave file</param>
		/// <param name="sampleRate">Sample rate of the wave file</param>
		/// <param name="bitsPerSample">Bits per sample of the wave file</param>
		public WaveWriter(string fileName, ushort numChannels, uint sampleRate, ushort bitsPerSample)
		{
			Initialize(fileName, numChannels, sampleRate, bitsPerSample, 1, false);
		}

		/// <summary> Write the samples processed in a wave file </summary>
		/// <param name="fileName">Name of the wave file</param>
		/// <param name="numChannels">Number of channels of the wave file</param>
		/// <param name="sampleRate">Sample rate of the wave file</param>
		/// <param name="bitsPerSample">Bits per sample of the wave file</param>
		/// <param name="rewrite">Rewrite the file if it already exists</param>
		/// <param name="g">Gain aplied to the signal when converted from 32 to 16 bits</param>
		public WaveWriter(string fileName, ushort numChannels, uint sampleRate, ushort bitsPerSample, float g, bool rewrite)
		{
			Initialize(fileName, numChannels, sampleRate, bitsPerSample, g, rewrite);
		}

		// //////////////////////////////////////////////////////////////////////////////////////////////////
		// Metodos Auxiliares
		// //////////////////////////////////////////////////////////////////////////////////////////////////

		private void Initialize(string fileName, ushort numChannels, uint sampleRate, ushort bitsPerSample, float g, bool rewrite)
		{
			_dataSize = 0;
			_gain = g;

			if (File.Exists(fileName)) 
			{
				if(rewrite == false)
					throw(new Exception("Arquivo já existe!!!!"));
			}
			
			_fs = new FileStream(fileName, FileMode.Create);
			_bs = new BufferedStream(_fs, 32768);
			_w  = new BinaryWriter(_bs);

			this.WriteWaveHeader(numChannels, sampleRate, bitsPerSample);
			
		}

		private void WriteWaveHeader(ushort numChannels, uint sampleRate, ushort bitsPerSample)
		{
			try
			{
				
				// Write Riff ///////////////////////////////////////////////

				_w.Write('R');
				_w.Write('I');
				_w.Write('F');
				_w.Write('F');
				_w.Write( (uint) 62);

				// Write Wave //////////////////////////////////////////////

				_w.Write('W');
				_w.Write('A');
				_w.Write('V');
				_w.Write('E');

				// Write Format ////////////////////////////////////////////

				_w.Write('f');
				_w.Write('m');
				_w.Write('t');
				_w.Write(' ');
				_w.Write((uint) 16);
				_w.Write((ushort) 1);

				_w.Write((ushort) numChannels);  //NunChannels
				_w.Write((uint) sampleRate); //SampleRate
				_w.Write((uint) ((numChannels * bitsPerSample * sampleRate) / 8)); //ByteRate
				//_w.Write('Q');
				_w.Write((ushort) ((numChannels * bitsPerSample) / 8) ); //BlockAlign
				//_w.Write('Q');
				_w.Write((ushort) 16); //BitsPerSample
		
				// Write Data ///////////////////////////////////////////////

				_w.Write('d');
				_w.Write('a');
				_w.Write('t');
				_w.Write('a');

				// Write Data Size //////////////////////////////////////////
				
				_w.Write((uint) 30);

				// Write Data ///////////////////////////////////////////////
				//				int i;
				//
				//				for(i = 0; i < 10; i++)
				//					_w.Write( (short) 16384);

			}
			catch (Exception e) 
			{
				throw(e);
			}
		}

		#endregion

		#region OVERRIDE
		// //////////////////////////////////////////////////////////////////////////////////////////////////
		//Overrides
		// //////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary> Do the signal processing </summary>
		public override void DoProcess()
		{
			short sampleShort;

			_dataSize++;

			try
			{	
				if(_gain * base._input.Output > 32767)
					sampleShort = 32767;
				else if(_gain * base._input.Output < -32768)
					sampleShort = -32768;
				else
					sampleShort = Convert.ToInt16(_gain * base._input.Output);
			}
			catch(OverflowException e) 
			{
				if(base._input.Output >= (float)Int16.MaxValue)
					sampleShort = Int16.MaxValue;
				else
					sampleShort = Int16.MinValue;
			}
			
			_w.Write(sampleShort);

			base._output = base._input.Output;
		}

		/// <summary> Number of interations expected to do the signal processing </summary>
		public override int Interations
		{
			get{return(base._input.Interations);}
		}

		#endregion

		#region METODOS
		// //////////////////////////////////////////////////////////////////////////////////////////////////
		// Metodos
		// //////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary> Close the wave file </summary>
		public void Close()
		{
			_bs.Seek(4, SeekOrigin.Begin);
			_w.Write((uint) (2 * _dataSize + 36));

			_bs.Seek(40, SeekOrigin.Begin);
			_w.Write((uint) (2 * _dataSize));

			_w.Close();
			_bs.Close();
			_fs.Close();
		}

		#endregion

	} // Classe
} // Namespace
