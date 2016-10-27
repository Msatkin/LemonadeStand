using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;


namespace LemonadeStand
{
    class Audio
    {
        public Audio()
        {
            PlayMusic();
        }

        private void PlayMusic()
        {
            SoundPlayer audioplayer = new SoundPlayer();
            audioplayer.SoundLocation = "background.wav";
            audioplayer.PlayLooping();
        }
    }
}
