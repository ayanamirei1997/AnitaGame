namespace Anita
{
    public class TextFadeInAnimationProperty : IAnimationProperty
    {
        private readonly TextProxy text;
        private readonly byte targetAlpha;

        public TextFadeInAnimationProperty(TextProxy text, byte targetAlpha)
        {
            this.text = text;
            this.targetAlpha = targetAlpha;
            // avoid undesired flash on the first frame
            value = 0.0f;
        }

        private float _value;

        public float value
        {
            get => _value;
            set
            {
                _value = value;
                text.SetFade(targetAlpha, value);
            }
        }
    }
}