using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Media;

namespace MathPracticePlatform.Services
{
    public class AudioService
    {
        private readonly MediaPlayer _mediaPlayer;

        public AudioService()
        {
            _mediaPlayer = new MediaPlayer();
        }

        public void PlaySound(string soundPath)
        {
            _mediaPlayer.Open(new Uri(soundPath, UriKind.RelativeOrAbsolute));
            _mediaPlayer.Play();
        }
    }
}
