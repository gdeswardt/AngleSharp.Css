namespace AngleSharp.Css.Values
{
    using AngleSharp.Text;
    using System;
    using System.Globalization;

    /// <summary>
    /// Represents a cubic-bezier timing-function object.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/timing-function
    /// </summary>
    public sealed class CubicBezierTimingFunction : ITimingFunction, IEquatable<CubicBezierTimingFunction>
    {
        #region Fields

        private readonly Double _x1;
        private readonly Double _y1;
        private readonly Double _x2;
        private readonly Double _y2;

        /// <summary>
        /// The pre-configured ease function.
        /// </summary>
        public static readonly CubicBezierTimingFunction Ease = new CubicBezierTimingFunction(0.25, 0.1, 0.25, 1.0);

        /// <summary>
        /// The pre-configured ease-in function.
        /// </summary>
        public static readonly CubicBezierTimingFunction EaseIn = new CubicBezierTimingFunction(0.42, 0.0, 1.0, 1.0);

        /// <summary>
        /// The pre-configured ease-out function.
        /// </summary>
        public static readonly CubicBezierTimingFunction EaseOut = new CubicBezierTimingFunction(0.0, 0.0, 0.58, 1.0);

        /// <summary>
        /// The pre-configured ease-in-out function.
        /// </summary>
        public static readonly CubicBezierTimingFunction EaseInOut = new CubicBezierTimingFunction(0.42, 0.0, 0.58, 1.0);

        /// <summary>
        /// The pre-configured linear function.
        /// </summary>
        public static readonly CubicBezierTimingFunction Linear = new CubicBezierTimingFunction(0.0, 0.0, 1.0, 1.0);

        #endregion

        #region ctor

        /// <summary>
        /// The four values specify points P1 and P2 of the curve as (x1, y1, x2, y2). Both
        /// x values must be in the range [0, 1] or the definition is invalid. The y values
        /// can exceed this range.
        /// </summary>
        /// <param name="x1">The x-coordinate of P1.</param>
        /// <param name="y1">The y-coordinate of P1.</param>
        /// <param name="x2">The x-coordinate of P2.</param>
        /// <param name="y2">The y-coordinate of P2.</param>
        public CubicBezierTimingFunction(Double x1, Double y1, Double x2, Double y2)
        {
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the CSS text representation.
        /// </summary>
        public String CssText
        {
            get { return ToString(); }
        }

        /// <summary>
        /// Gets the x-coordinate of the p1.
        /// </summary>
        public Double X1
        {
            get { return _x1; }
        }

        /// <summary>
        /// Gets the y-coordinate of the p1.
        /// </summary>
        public Double Y1
        {
            get { return _y1; }
        }

        /// <summary>
        /// Gets the x-coordinate of the p2.
        /// </summary>
        public Double X2
        {
            get { return _x2; }
        }

        /// <summary>
        /// Gets the y-coordinate of the p2.
        /// </summary>
        public Double Y2
        {
            get { return _y2; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Checks with equality to another cubic bezier timing function.
        /// </summary>
        /// <param name="other">The cubic bezier to compare to.</param>
        /// <returns>True if both have the same parameters, otherwise false.</returns>
        public Boolean Equals(CubicBezierTimingFunction other)
        {
            return _x1 == other._x1 && _x2 == other._x2 && _y1 == other._y1 && _y2 == other._y2;
        }

        /// <summary>
        /// Serializes to a string.
        /// </summary>
        public override String ToString()
        {
            if (Equals(Ease))
            {
                return CssKeywords.Ease;
            }
            else if (Equals(EaseIn))
            {
                return CssKeywords.EaseIn;
            }
            else if (Equals(EaseOut))
            {
                return CssKeywords.EaseOut;
            }
            else if (Equals(EaseInOut))
            {
                return CssKeywords.EaseInOut;
            }
            else if (Equals(Linear))
            {
                return CssKeywords.Linear;
            }
            else
            {
                var fn = FunctionNames.CubicBezier;
                var args = new[]
                {
                    _x1.ToString(CultureInfo.InvariantCulture),
                    _y1.ToString(CultureInfo.InvariantCulture),
                    _x2.ToString(CultureInfo.InvariantCulture),
                    _y2.ToString(CultureInfo.InvariantCulture)
                };
                return fn.CssFunction(String.Join(", ", args));
            }
        }

        #endregion
    }
}
