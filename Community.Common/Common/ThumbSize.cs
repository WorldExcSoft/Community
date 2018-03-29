using System.Drawing;

namespace Community.Common
{
    /// <summary>
    /// 缩略图尺寸
    /// </summary>
    public class ThumbSize
    {
        public Size New { get; set; }
        public Size Src { get; set; }

        public Point Point { get; set; }

        public Rectangle getRect()
        {
            return new Rectangle(this.Point.X, this.Point.Y, this.Src.Width, this.Src.Height);
        }

        public Rectangle getNewRect()
        {
            return new Rectangle(0, 0, this.New.Width, this.New.Height);
        }
    }
}
