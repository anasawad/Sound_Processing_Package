using System;

namespace Garbe.Sound
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Echo_Effect_Filter : SoundObj
    {
        #region Declarations

        float m_alpha;
        int m_delay;
        Delay m_delayObj;
        Mixer m_mixer;

        #endregion

        #region Constructors

        /// <summary>
        /// </summary>
        /// <param name="p_soundObj">"Wave Reader Object"</param>
        /// <param name="p_delay">"Delay Value"</param>
        /// <param name="p_alpha">"Gain Value"</param>
        public Echo_Effect_Filter(SoundObj p_soundObj, int p_delay, float p_alpha)
            : base()
        {
            m_alpha          = p_alpha;
            m_delay          = p_delay;
            this.Input       = p_soundObj;
            m_delayObj       = new Delay((int)(m_delay * m_alpha));
            m_delayObj.Input = p_soundObj;
            m_mixer          = new Mixer(2);
            m_mixer[0]       = m_delayObj;
            m_mixer[1]       = p_soundObj;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Do Signal Processing by mixing the delayed signal and the original Signal 
        /// </summary>
        public override void DoProcess()
        {
            m_delayObj.DoProcess();
            m_mixer.DoProcess();
        }

        #endregion

        #region Properties
        public Mixer Get_Mixer
        {
           get{return this.m_mixer;}
        }
        /// <summary>
        /// Gets the expected number of interations to be processed 
        /// </summary>
        public override int Interations
        {
            get { return (base._input.Interations); }
        }
        #endregion
    }
}

