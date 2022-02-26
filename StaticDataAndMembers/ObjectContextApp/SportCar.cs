using System;
using System.Runtime.Remoting.Contexts;// Для типа Context,
using System.Threading; // Для типа Thread.
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectContextApp
{
    // Класс SportsCar не имеет никаких специальных
    // контекстных потребностей и будет загружаться
    // е стандартный контекст домена приложения,
    class SportsCar
    {
        public SportsCar()
        {
            // Получить информацию о контексте и вывести идентификатор контекста
            Context ctx = Thread.CurrentContext;
            Console.WriteLine("{0} object in context {1}", this.ToString(), ctx.ContextID);
            foreach (IContextProperty itfCtxProp in ctx.ContextProperties)
                Console.WriteLine("-> Ctx Prop: {0} ", itfCtxProp.Name);
        }
    }
    // SportsCarTS требует загрузки в синхронизированный контекст.
    [Synchronization]
    class SportsCarTS : ContextBoundObject
    {
        public SportsCarTS()
        { 
            // Получить информацию о контексте и вывести идентификатор контекста
            Context ctx = Thread.CurrentContext;
            Console.WriteLine("{0} object in context {1}", this.ToString(), ctx.ContextID);
            foreach (IContextProperty itfCtxProp in ctx.ContextProperties)
                Console.WriteLine("-> Ctx Prop: {0} ", itfCtxProp.Name);
        }
    }
}
