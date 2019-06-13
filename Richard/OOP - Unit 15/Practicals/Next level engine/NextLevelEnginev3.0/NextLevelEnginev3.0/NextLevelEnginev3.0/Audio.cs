using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace NextLevelEngine.Audio
{
    public class songAudio
    {
        public Song songName;

        public void Load(string assetName, ContentManager content)
        {
            songName = content.Load<Song>(assetName);
        }

        public void Play()
        {
            MediaPlayer.Play(songName);
        }
    }

    public class soundEffectAudio
    {
        public SoundEffect effectName;

        public void Load(string assetName, ContentManager content)
        {
            effectName = content.Load<SoundEffect>(assetName);
        }

        public void Play()
        {
            effectName.Play();
        }
    }
}
