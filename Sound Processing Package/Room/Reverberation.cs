using System;

namespace Garbe.Sound
{
    /// <summary> Calculate the signal with echo effects </summary>
    public sealed class Reverberation : SoundObj
    {
        Multi_Echo_Effect_Filter m_multi_Echo1;
        Multi_Echo_Effect_Filter m_multi_Echo2;
        Multi_Echo_Effect_Filter m_multi_Echo3;
        Multi_Echo_Effect_Filter m_multi_Echo4;
        Gain                     m_gain;
        Delay                    m_delay;
        AllPass                  m_allPass1;
        AllPass m_allPass2;
        Mixer                    m_mixer;

        float m_alpha;


        public Reverberation(SoundObj p_soundObj, float p_alpha, int p_delay)
        {
            m_delay = new Delay(p_delay);
            m_multi_Echo1 = new Multi_Echo_Effect_Filter(p_alpha,p_delay);
            m_multi_Echo2 = new Multi_Echo_Effect_Filter(p_alpha,p_delay);
            m_multi_Echo3 = new Multi_Echo_Effect_Filter(p_alpha,p_delay);
            m_multi_Echo4 = new Multi_Echo_Effect_Filter(p_alpha,p_delay);
            m_allPass1 = new AllPass(p_alpha,p_delay);
            m_allPass2 = new AllPass(p_alpha, p_delay);

            m_multi_Echo1.Input = p_soundObj;
            m_multi_Echo2.Input = p_soundObj;
            m_multi_Echo3.Input = p_soundObj;
            m_multi_Echo4.Input = p_soundObj ;
            m_allPass1.Input = p_soundObj;
            m_allPass2.Input = p_soundObj;
           
            m_mixer = new Mixer(6);
            m_mixer[0] = m_multi_Echo1;
            m_mixer[1] = m_multi_Echo2;
            m_mixer[2] = m_multi_Echo3;
            m_mixer[3] = m_multi_Echo4;
            m_mixer[4] = m_allPass1;
            m_mixer[5] = m_allPass2;
           // m_mixer[6] = p_soundObj;

        }
        public Mixer GetMixer
        {
            get { return this.m_mixer; }
        }
        public override void DoProcess()
        {
           m_multi_Echo1.Input.DoProcess();
           m_multi_Echo2.Input.DoProcess();
           m_multi_Echo3.Input.DoProcess();
           m_multi_Echo4.Input.DoProcess();

            m_allPass1.Input.DoProcess();
            m_allPass2.Input.DoProcess();
            m_mixer.DoProcess();
        }

        public override int Interations
        {
            get { return (base._input.Interations); }
        }
    }
}
