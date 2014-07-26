using System;
using System.IO;

namespace Garbe.Sound
{
	/// <summary> Read a wave file </summary>
	public sealed class WaveReader : SoundObj
	{

		// //////////////////////////////////////////////////////////////////////////////////////////////////
		// Membros da Classe
		// //////////////////////////////////////////////////////////////////////////////////////////////////

		private FileStream fs;
		private BinaryReader r;
		private BufferedStream bs;

		private string _riff;
		private uint   _lenght;
		private string _wave;
		private string _format;

		private uint   _size;
		private ushort _audioFormat; //Format Tag -- precisa ser 1 !!!!!!!!
		private ushort _numChannels;
		private uint   _sampleRate;
		private uint   _byteRate;
		private ushort _blockAlign;
		private ushort _bitsPerSample;

		private string _data;
		private uint   _dataSize;

		private bool   _eof;
		private int    _pos; // position
		private int    _max; // maximum position

		#region CONSTRUTORES

		// //////////////////////////////////////////////////////////////////////////////////////////////////
		// Construtores
		// //////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary> Read a wave file </summary>
		/// <param name="fileName">Name of the wave file</param>
		public WaveReader(string fileName)
		{
			if (File.Exists(fileName)) 
			{
				fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
				bs = new BufferedStream(fs, 512);
				r = new BinaryReader(bs);

				this.ReadWaveHeader();
			}
			else
			{
				throw(new Exception("File " + fileName + " not founded!!!"));
			}

		} // Construtor

		// //////////////////////////////////////////////////////////////////////////////////////////////////
		// Metodos Auxiliares
		// //////////////////////////////////////////////////////////////////////////////////////////////////

		private void ReadWaveHeader()
		{
			try
			{
				
				// Read Riff ///////////////////////////////////////////////

				_riff = new string (r.ReadChars(4));
				if(_riff != "RIFF") 
					throw(new Exception("No Tag RIFF!!!"));

				_lenght = r.ReadUInt32();

				// Read Wave //////////////////////////////////////////////

				_wave = new string (r.ReadChars(4));
				if(_wave != "WAVE")
					throw(new Exception("No Tag WAVE!!!"));

				// Read Format ////////////////////////////////////////////

				_format = new string (r.ReadChars(4));
				if(_format != "fmt ")
					throw(new Exception("No Tag fmt !!!"));

                //format length
				_size = r.ReadUInt32();
				if(_size < 16)
					throw(new Exception("Size of fmt different of 16"));
		
				_audioFormat = r.ReadUInt16();
				//if(_audioFormat != 1)
				//	throw(new Exception("AudioFormat of fmt different of 1"));
		
				_numChannels = r.ReadUInt16();				
				_sampleRate = r.ReadUInt32();				
				_byteRate = r.ReadUInt32();				
				_blockAlign = r.ReadUInt16();				
				_bitsPerSample = r.ReadUInt16();

                if (_size > 16)
                {
                    r.ReadBytes((int)_size - 16);
                }

				// Read Data ///////////////////////////////////////////////

				_data = new string (r.ReadChars(4));

                while (_data != "data")
                {
                    _data = new string(r.ReadChars(4));
                }
				// Read Data Size //////////////////////////////////////////
				
				_dataSize = r.ReadUInt32();

				_eof = false;
				_pos = 0;
				_max = (int)(8 * _dataSize / _bitsPerSample / _numChannels);

			}
			catch (Exception e) 
			{
				throw(e);
			}
		} // ReadWaveHeader

		#endregion

		#region OVERRIDE
		// //////////////////////////////////////////////////////////////////////////////////////////////////
		// Override
		// //////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary> Do the signal processing </summary>
		public override void DoProcess()
		{
			try
			{
				_pos++;

				if(_pos <= _max)
					base._output = (float)r.ReadInt16();
				else
					base._output = 0;
			}
			catch(EndOfStreamException e)
			{
				_eof = true;
				base._output = 0;
			}
		}

		/// <summary> Number of interations expected to do the signal processing </summary>
		public override int Interations
		{
			get{return((int)(8 * _dataSize / _bitsPerSample / _numChannels));}
		}

		/// <summary> Gets the number of channels of the signal </summary>
		public override ushort NumChannels
		{
			get { return _numChannels; }
		}

		/// <summary> Gets the sample rate of the signal </summary>
		public override uint SampleRate
		{
			get { return _sampleRate; }
		}
		
		#endregion

		#region METODOS

		// //////////////////////////////////////////////////////////////////////////////////////////////////
		// Metodos
		// //////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary> Close the wave file </summary>
		public void Close()
		{
			r.Close();
			bs.Close();
			fs.Close();
		}

		#endregion

		#region PROPRIEDADES

		/// <summary> Get the RIFF tag </summary>
		public string Riff
		{
			get { return _riff; }
		}

		/// <summary> Get the Lenght tag </summary>
		public uint Lenght
		{
			get { return _lenght; }
		}

		/// <summary> Get the Wave tag </summary>
		public string Wave
		{
			get 
			{ return _wave; }
		}

		/// <summary> Get the Format tag </summary>
		public string Format
		{
			get 
			{ return _format; }
		}

		/// <summary> Get the Size tag </summary>
		public uint Size
		{
			get { return _size; }
		}

		/// <summary> Get the Audio Format tag </summary>
		public ushort AudioFormat
		{
			get { return _audioFormat; }
		}

		/// <summary> Get the Byte Rate tag </summary>
		public uint ByteRate
		{
			get { return _byteRate; }
		}

		/// <summary> Get the Block Align tag </summary>
		public ushort BlockAlign
		{
			get { return _blockAlign; }
		}

		/// <summary> Get the Bits per Samples tag </summary>
		public ushort BitsPerSamples
		{
			get { return _bitsPerSample; }
		}

		/// <summary> Get the Data tag </summary>
		public string Data
		{
			get { return _data; }
		}

		/// <summary> Get the Data Size tag </summary>
		public uint DataSize
		{
			get { return _dataSize; }
		}

		/// <summary> Get the information if the End of File is reached </summary>
		public bool EOF
		{
			get { return _eof; }
		}



		#endregion


	} //Classe
}//Namespace
