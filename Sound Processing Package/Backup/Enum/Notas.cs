using System;

namespace Garbe.Sound
{
	/// <summary> Enumarate the notes in the 10 oitaves hearded </summary>
	public enum Notas
	{
		// Oitava Zero

		/// <summary> C0 Note </summary>
		C0  =   0,
		/// <summary> C#0 Note </summary>
		Cs0 =   1,
		/// <summary> Db0 Note </summary>
		Db0 =   1,
		/// <summary> D0 Note </summary>
		D0  =   2,
		/// <summary> D#0 Note </summary>
		Ds0 =   3,
		/// <summary> Eb0 Note </summary>
		Eb0 =   3,
		/// <summary> E0 Note </summary>
		E0  =   4,
		/// <summary> F0 Note </summary>
		F0  =   5,
		/// <summary> F#0 Note </summary>
		Fs0 =   6,
		/// <summary> Gb0 Note </summary>
		Gb0 =   6,
		/// <summary> G0 Note </summary>
		G0  =   7,
		/// <summary> G#0 Note </summary>
		Gs0 =   8,
		/// <summary> Ab0 Note </summary>
		Ab0 =   8,
		/// <summary> A0 Note </summary>
		A0  =   9,
		/// <summary> As0 Note </summary>
		As0 =  10,
		/// <summary> Bb0 Note </summary>
		Bb0 =  10,
		/// <summary> B0 Note </summary>
		B0  =  11,

		// Primeira Oitava

		/// <summary> C1 Note </summary>
		C1  =   0 + 12,
		/// <summary> C#1 Note </summary>
		Cs1 =   1 + 12,
		/// <summary> Db1 Note </summary>
		Db1 =   1 + 12,
		/// <summary> D1 Note </summary>
		D1  =   2 + 12,
		/// <summary> Ds1 Note </summary>
		Ds1 =   3 + 12,
		/// <summary> Eb1 Note </summary>
		Eb1 =   3 + 12,
		/// <summary> E1 Note </summary>
		E1  =   4 + 12,
		/// <summary> F1 Note </summary>
		F1  =   5 + 12,
		/// <summary> F#1 Note </summary>
		Fs1 =   6 + 12,
		/// <summary> Gb1 Note </summary>
		Gb1 =   6 + 12,
		/// <summary> G1 Note </summary>
		G1  =   7 + 12,
		/// <summary> G#1 Note </summary>
		Gs1 =   8 + 12,
		/// <summary> Ab1 Note </summary>
		Ab1 =   8 + 12,
		/// <summary> A1 Note </summary>
		A1  =   9 + 12,
		/// <summary> A#1 Note </summary>
		As1 =  10 + 12,
		/// <summary> Bb1 Note </summary>
		Bb1 =  10 + 12,
		/// <summary> B1 Note </summary>
		B1  =  11 + 12,

		// Segunda Oitava

		/// <summary> C2 Note </summary>
		C2  =   0 + 24,
		/// <summary> C#2 Note </summary>
		Cs2 =   1 + 24,
		/// <summary> Db2 Note </summary>
		Db2 =   1 + 24,
		/// <summary> D2 Note </summary>
		D2  =   2 + 24,
		/// <summary> D#2 Note </summary>
		Ds2 =   3 + 24,
		/// <summary> Eb2 Note </summary>
		Eb2 =   3 + 24,
		/// <summary> E2 Note </summary>
		E2  =   4 + 24,
		/// <summary> F2 Note </summary>
		F2  =   5 + 24,
		/// <summary> F#2 Note </summary>
		Fs2 =   6 + 24,
		/// <summary> Gb2 Note </summary>
		Gb2 =   6 + 24,
		/// <summary> G2 Note </summary>
		G2  =   7 + 24,
		/// <summary> G#2 Note </summary>
		Gs2 =   8 + 24,
		/// <summary> Ab2 Note </summary>
		Ab2 =   8 + 24,
		/// <summary> A2 Note </summary>
		A2  =   9 + 24,
		/// <summary> A#2 Note </summary>
		As2 =  10 + 24,
		/// <summary> Bb2 Note </summary>
		Bb2 =  10 + 24,
		/// <summary> B2 Note </summary>
		B2  =  11 + 24,

		// Terceira Oitava

		/// <summary> C3 Note </summary>
		C3  =   0 + 36,
		/// <summary> C#3 Note </summary>
		Cs3 =   1 + 36,
		/// <summary> Db3 Note </summary>
		Db3 =   1 + 36,
		/// <summary> D3 Note </summary>
		D3  =   2 + 36,
		/// <summary> D#3 Note </summary>
		Ds3 =   3 + 36,
		/// <summary> Eb3 Note </summary>
		Eb3 =   3 + 36,
		/// <summary> E3 Note </summary>
		E3  =   4 + 36,
		/// <summary> F3 Note </summary>
		F3  =   5 + 36,
		/// <summary> F#3 Note </summary>
		Fs3 =   6 + 36,
		/// <summary> Gb3 Note </summary>
		Gb3 =   6 + 36,
		/// <summary> G3 Note </summary>
		G3  =   7 + 36,
		/// <summary> G#3 Note </summary>
		Gs3 =   8 + 36,
		/// <summary> Ab3 Note </summary>
		Ab3 =   8 + 36,
		/// <summary> A3 Note </summary>
		A3  =   9 + 36,
		/// <summary> A#3 Note </summary>
		As3 =  10 + 36,
		/// <summary> Bb3 Note </summary>
		Bb3 =  10 + 36,
		/// <summary> B3 Note </summary>
		B3  =  11 + 36,

		// Quarta Oitava

		/// <summary> C4 Note </summary>
		C4  =   0 + 48,
		/// <summary> C#4 Note </summary>
		Cs4 =   1 + 48,
		/// <summary> Db4 Note </summary>
		Db4 =   1 + 48,
		/// <summary> D4 Note </summary>
		D4  =   2 + 48,
		/// <summary> D#4 Note </summary>
		Ds4 =   3 + 48,
		/// <summary> Eb4 Note </summary>
		Eb4 =   3 + 48,
		/// <summary> E4 Note </summary>
		E4  =   4 + 48,
		/// <summary> F4 Note </summary>
		F4  =   5 + 48,
		/// <summary> F#4 Note </summary>
		Fs4 =   6 + 48,
		/// <summary> Gb4 Note </summary>
		Gb4 =   6 + 48,
		/// <summary> G4 Note </summary>
		G4  =   7 + 48,
		/// <summary> G#4 Note </summary>
		Gs4 =   8 + 48,
		/// <summary> Ab4 Note </summary>
		Ab4 =   8 + 48,
		/// <summary> A4 Note </summary>
		A4  =   9 + 48,
		/// <summary> A#4 Note </summary>
		As4 =  10 + 48,
		/// <summary> Bb4 Note </summary>
		Bb4 =  10 + 48,
		/// <summary> B4 Note </summary>
		B4  =  11 + 48,

		// Quinta Oitava

		/// <summary> C5 Note </summary>
		C5  =   0 + 60,
		/// <summary> C#5 Note </summary>
		Cs5 =   1 + 60,
		/// <summary> Db5 Note </summary>
		Db5 =   1 + 60,
		/// <summary> D5 Note </summary>
		D5  =   2 + 60,
		/// <summary> D#5 Note </summary>
		Ds5 =   3 + 60,
		/// <summary> Eb5 Note </summary>
		Eb5 =   3 + 60,
		/// <summary> E5 Note </summary>
		E5  =   4 + 60,
		/// <summary> F5 Note </summary>
		F5  =   5 + 60,
		/// <summary> F#5 Note </summary>
		Fs5 =   6 + 60,
		/// <summary> Gb5 Note </summary>
		Gb5 =   6 + 60,
		/// <summary> G5 Note </summary>
		G5  =   7 + 60,
		/// <summary> G#5 Note </summary>
		Gs5 =   8 + 60,
		/// <summary> Ab5 Note </summary>
		Ab5 =   8 + 60,
		/// <summary> A5 Note </summary>
		A5  =   9 + 60,
		/// <summary> A#5 Note </summary>
		As5 =  10 + 60,
		/// <summary> Bb5 Note </summary>
		Bb5 =  10 + 60,
		/// <summary> B5 Note </summary>
		B5  =  11 + 60,

		// Sexta Oitava

		/// <summary> C6 Note </summary>
		C6  =   0 + 72,
		/// <summary> C#6 Note </summary>
		Cs6 =   1 + 72,
		/// <summary> Db6 Note </summary>
		Db6 =   1 + 72,
		/// <summary> D6 Note </summary>
		D6  =   2 + 72,
		/// <summary> D#6 Note </summary>
		Ds6 =   3 + 72,
		/// <summary> Eb6 Note </summary>
		Eb6 =   3 + 72,
		/// <summary> E6 Note </summary>
		E6  =   4 + 72,
		/// <summary> F6 Note </summary>
		F6  =   5 + 72,
		/// <summary> F#6 Note </summary>
		Fs6 =   6 + 72,
		/// <summary> Gb6 Note </summary>
		Gb6 =   6 + 72,
		/// <summary> G6 Note </summary>
		G6  =   7 + 72,
		/// <summary> Gs6 Note </summary>
		Gs6 =   8 + 72,
		/// <summary> Ab6 Note </summary>
		Ab6 =   8 + 72,
		/// <summary> A6 Note </summary>
		A6  =   9 + 72,
		/// <summary> A#6 Note </summary>
		As6 =  10 + 72,
		/// <summary> Bb6 Note </summary>
		Bb6 =  10 + 72,
		/// <summary> B6 Note </summary>
		B6  =  11 + 72,

		// Setima Oitava

		/// <summary> C7 Note </summary>
		C7  =   0 + 84,
		/// <summary> C#7 Note </summary>
		Cs7 =   1 + 84,
		/// <summary> Db7 Note </summary>
		Db7 =   1 + 84,
		/// <summary> D7 Note </summary>
		D7  =   2 + 84,
		/// <summary> D#7 Note </summary>
		Ds7 =   3 + 84,
		/// <summary> Eb7 Note </summary>
		Eb7 =   3 + 84,
		/// <summary> E7 Note </summary>
		E7  =   4 + 84,
		/// <summary> F7 Note </summary>
		F7  =   5 + 84,
		/// <summary> F#7 Note </summary>
		Fs7 =   6 + 84,
		/// <summary> Gb7 Note </summary>
		Gb7 =   6 + 84,
		/// <summary> G7 Note </summary>
		G7  =   7 + 84,
		/// <summary> G#7 Note </summary>
		Gs7 =   8 + 84,
		/// <summary> Ab7 Note </summary>
		Ab7 =   8 + 84,
		/// <summary> A7 Note </summary>
		A7  =   9 + 84,
		/// <summary> A#7 Note </summary>
		As7 =  10 + 84,
		/// <summary> Bb7 Note </summary>
		Bb7 =  10 + 84,
		/// <summary> B7 Note </summary>
		B7  =  11 + 84,


	}
}
