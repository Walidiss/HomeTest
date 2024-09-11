using GetDinners.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GetDinners.Domain.Menus.ValueObjects
{

    public sealed class MenuItemId : AggregateRootId<Guid>
    {
        public override Guid Value {get; protected set;}

        //Le constructeur est private, ce qui signifie que la classe MenuItemId ne peut être instanciée que de l'intérieur de la classe elle-même.
        //Il prend un Guid comme paramètre et l'affecte à la propriété Value.
        //Cette approche garantit que l'instance de MenuItemId ne peut être créée que via les méthodes définies à l'intérieur de la classe, comme CreateUnique().
        private MenuItemId(Guid value)
        {
            Value = value;
        }

        //CreateUnique() est une méthode statique qui permet de créer une nouvelle instance unique de MenuItemId.
        // Elle génère un Guid unique avec Guid.NewGuid() et l'utilise pour créer une nouvelle instance de MenuItemId.
        //Cette méthode est un exemple d'une factory method, qui est une méthode statique utilisée pour contrôler l'instanciation des objets.
        public static MenuItemId CreateUnique()
        {
            return new MenuItemId(Guid.NewGuid());
        }

        public static MenuItemId Create(Guid value)
        {

            return new MenuItemId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
#pragma warning disable CS8618

        private MenuItemId()
        {
        }

#pragma warning restore CS8618
    }
}
