using Microsoft.Xna.Framework;

namespace Engine
{
    public class CollisionDetection
    {
        #region Public Methods
        /// <summary>
        /// Checks and returns whether two circles interseet
        /// </summary>
        /// <param name="circle1">A circle of some object</param>
        /// <param name="circle2">A circle of some other object</param>
        /// <returns></returns>
        public static bool ShapesIntersect(Circle circle1, Circle circle2)
        {
            return Vector2.Distance(circle1.Center, circle2.Center) <= circle1.Radius + circle2.Radius;
        }
        /// <summary>
        /// Check and return whether two rectangles intersect
        /// </summary>
        /// <param name="rectangle1">A rectangle of some object</param>
        /// <param name="rectangle2">A rectangle of some other object</param>
        /// <returns></returns>
        public static bool ShapesIntersect(Rectangle rectangle1, Rectangle rectangle2)
        {
            return rectangle1.Intersects(rectangle2);
        }
        /// <summary>
        /// Check and returns whether a a rectangle and a circle intersect
        /// </summary>
        /// <param name="rectangle"></param>
        /// <param name="circle"></param>
        /// <returns></returns>
        public static bool ShapesIntersect(Rectangle rectangle, Circle circle)
        {
            Vector2 closestPoint;
            closestPoint.X = MathHelper.Clamp(circle.Center.X, rectangle.Left, rectangle.Right);
            closestPoint.Y = MathHelper.Clamp(circle.Center.Y, rectangle.Top, rectangle.Bottom);
            return Vector2.Distance(circle.Center, closestPoint) <= circle.Radius;
        }
        public static Rectangle CalculateIntersection(Rectangle rect1, Rectangle rect2)
        {
            if (!ShapesIntersect(rect1, rect2))
            {
                return new Rectangle(0, 0, 0, 0);
            }
            int xmin = Math.Max(rect1.Left, rect2.Left);
            int xmax = Math.Min(rect1.Right, rect2.Right);
            int ymin = Math.Max(rect1.Top, rect2.Top);
            int ymax = Math.Min(rect1.Bottom, rect2.Bottom);
            return new Rectangle(xmin, ymin, xmax - xmin, ymax - ymin);
        }

        #endregion
    }
}
