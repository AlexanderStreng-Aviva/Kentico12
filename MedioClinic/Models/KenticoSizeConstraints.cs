using Kentico.Content.Web.Mvc;

namespace MedioClinic.Models
{
    /// <summary>
    ///     Interface for size constrains so that we can avoid using Kentico code directly in views
    /// </summary>
    public interface IImageSizeConstraint
    {
        SizeConstraint GetSizeConstraint();
    }

    // Specifies the maximum width of the image
    public class Width : IImageSizeConstraint
    {
        private readonly int _width;

        public Width(int width)
        {
            _width = width;
        }

        public SizeConstraint GetSizeConstraint()
        {
            return SizeConstraint.Width(_width);
        }
    }

    // Specifies the maximum height of the image
    public class Height : IImageSizeConstraint
    {
        private readonly int _height;

        public Height(int height)
        {
            _height = height;
        }

        public SizeConstraint GetSizeConstraint()
        {
            return SizeConstraint.Height(_height);
        }
    }

    // Specifies the maximum width and height of the image
    public class MaxWidthOrHeight : IImageSizeConstraint
    {
        private readonly int _maxWidthOrHeight;

        public MaxWidthOrHeight(int maxWidthOrHeight)
        {
            _maxWidthOrHeight = maxWidthOrHeight;
        }

        public SizeConstraint GetSizeConstraint()
        {
            return SizeConstraint.MaxWidthOrHeight(_maxWidthOrHeight);
        }
    }
}