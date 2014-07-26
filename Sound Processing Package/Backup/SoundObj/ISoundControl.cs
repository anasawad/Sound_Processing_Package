using System;

namespace Garbe.Sound
{
	interface ISoundControl
	{
		void		DoProcess();
		bool		Enable		{get;}
		//string	Name			{get; set;}	
	}
}
