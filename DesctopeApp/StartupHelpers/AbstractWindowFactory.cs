using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesctopeApp.StartupHelpers
{
    public static class WindowsGraphExtension
    {
        public static void AddWindowFactory<TWindow>(this IServiceCollection services)
            where TWindow : Window
        {
            services.AddTransient<TWindow>();
            services.AddSingleton<Func<TWindow>>(x => () => x.GetService<TWindow>()!);
            services.AddSingleton<IAbstractWindowFactory<TWindow>, AbstractWindowFactory<TWindow>>();
        }
    }

    public interface IAbstractWindowFactory<T>
    {
        T Create();
    }

    public class AbstractWindowFactory<T> : IAbstractWindowFactory<T>
    {
        private readonly Func<T> factory;

        public AbstractWindowFactory(Func<T> factory)
        {
            this.factory = factory;
        }

        public T Create()
        {
            return factory();
        }
    }
}
