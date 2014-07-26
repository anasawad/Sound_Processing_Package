using System;

namespace Garbe.Sound
{
	interface ISoundObj
	{
		SoundObj Input			{get; set;}
		float		Output		{get;}

		ushort	NumChannels	{get;}
		uint		SampleRate	{get;}

		int		Interations {get;}
	}
}
