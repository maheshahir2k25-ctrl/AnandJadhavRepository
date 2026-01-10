using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial
{
    //If we are creating child class from parent class and we want to change the behavior of parent class method in child class then we can use Method Overriding.
    public class SamsungMusic
    {
        public virtual void Play()
        {
        }
    }
    public class AppleMusic : SamsungMusic
    {
        public AppleMusic()
        {

        }
        public override void Play()
        {
        }
    }
    public class GoogleMusic : AppleMusic
    {
        public GoogleMusic() : base()
        {

        }
        public override void Play()
        {
            base.Play();
            //Additional Implementation
        }
    }
    public class SonyMusic : AppleMusic
    {
        public SonyMusic() : base()
        {

        }
        public override void Play()
        {
            base.Play();
            //Additional Implementation
        }
    }
}
