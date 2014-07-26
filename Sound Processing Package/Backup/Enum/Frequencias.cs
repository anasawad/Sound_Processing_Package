using System;

namespace Garbe.Sound
{
	/// <summary> Calculate a Frequency based in some note </summary>
	public class Frequencias
	{

		#region Frequencias

		#endregion

		#region Proporcoes

		// Proporções na Oitava

		/// <summary> C Note Proportion in relation to C </summary>
		public const double C  = 1.0;
		/// <summary> C# Note Proportion in relation to C </summary>
		public const double Cs = 1.059463094;
		/// <summary> Db Note Proportion in relation to C </summary>
		public const double Db = 1.059463094;
		/// <summary> D Note Proportion in relation to C </summary>
		public const double D  = 1.122462048;
		/// <summary> D# Note Proportion in relation to C </summary>
		public const double Ds = 1.189207115;
		/// <summary> Eb Note Proportion in relation to C </summary>
		public const double Eb = 1.189207115;
		/// <summary> E Note Proportion in relation to C </summary>
		public const double E  = 1.259921050;
		/// <summary> F Note Proportion in relation to C </summary>
		public const double F  = 1.334839854;
		/// <summary> F# Note Proportion in relation to C </summary>
		public const double Fs = 1.414213562;
		/// <summary> Gb Note Proportion in relation to C </summary>
		public const double Gb = 1.414213562;
		/// <summary> G Note Proportion in relation to C </summary>
		public const double G  = 1.498307077;
		/// <summary> G# Note Proportion in relation to C </summary>
		public const double Gs = 1.587401052;
		/// <summary> Ab Note Proportion in relation to C </summary>
		public const double Ab = 1.587401052;
		/// <summary> A Note Proportion in relation to C </summary>
		public const double A  = 1.681792831;
		/// <summary> A# Note Proportion in relation to C </summary>
		public const double As = 1.781797436;
		/// <summary> Bb Note Proportion in relation to C </summary>
		public const double Bb = 1.781797436;
		/// <summary> B Note Proportion in relation to C </summary>
		public const double B  = 1.887748625;

		/// <summary> All the notes proportion in relation to C </summary>
		public static double[] TET12 = new double[12] {	1.0,
																		 1.059463094,
																		 1.122462048,
																		 1.189207115,
																		 1.259921050,
																		 1.334839854,
																		 1.414213562,
																		 1.498307077,
																		 1.587401052,
																		 1.681792831,
																		 1.781797436,
																		 1.887748625
																	 };

		#endregion

		/// <summary> Calculates the Frequency of the note </summary>
		/// <param name="nota">Note</param>
		/// <returns>Frequency of the note</returns>
		public static double Freq(Notas nota)
		{
			double valorLa = 440;
			Afinacoes afn = Afinacoes.TET12;

			return(Freq2(nota, afn, valorLa));
		}

		/// <summary> Calculates the Frequency of the note </summary>
		/// <param name="nota">Note</param>
		/// <param name="valorLa">Value of the A note in frequency</param>
		/// <returns>Frequency of the note</returns>
		public static double Freq(Notas nota, double valorLa)
		{
			Afinacoes afn = Afinacoes.TET12;

			return(Freq2(nota, afn, valorLa));
		}

		/// <summary> Calculates the Frequency of the note </summary>
		/// <param name="nota">Note</param>
		/// <param name="afn">Tunning used to calculate the frequency</param>
		/// <param name="valorLa">Value of the A note in frequency</param>
		/// <returns>Frequency of the note</returns>
		public static double Freq(Notas nota, Afinacoes afn, double valorLa)
		{
			return(Freq2(nota, afn, valorLa));
		}

		private static double Freq2(Notas nota, Afinacoes afn, double valorLa)
		{
			double f;
			int oitava;
			int notaAbs;

			oitava = Convert.ToInt32(nota) / 12;
			notaAbs = Convert.ToInt32(nota) % 12;

			f = (valorLa * Math.Pow(2, oitava - 4)) * (Frequencias.TET12[notaAbs] / Frequencias.TET12[9]);
			
			return(f);
		}


	}
}
