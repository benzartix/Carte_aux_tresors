using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carte_aux_tresors.Utilis
{
    public class ParsedInput
    {
        public Map Map { get; }
        public Aventurier aventurier { get; }

        public ParsedInput(Map map, Aventurier _aventurier)
        {
            Map = map;
            aventurier = _aventurier;
        }
    }
}
