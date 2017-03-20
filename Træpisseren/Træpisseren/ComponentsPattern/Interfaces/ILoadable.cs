using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace Træpisseren
{
    interface ILoadable
    {
        void LoadContent(ContentManager content);
    }
}
