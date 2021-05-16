using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.Content;
using Android.Graphics.Drawables;
using Microsoft.Maui;

namespace AP.MobileToolkit.Fonts.Controls
{
    partial class IconImageSourceService
    {
        public Task<IImageSourceServiceResult<Drawable>> GetDrawableAsync(IImageSource imageSource, Context context, CancellationToken cancellationToken = default)
        {
            if (imageSource is null)
            {
                throw new ArgumentNullException(nameof(imageSource));
            }

            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            throw new System.NotImplementedException();
        }
    }
}
