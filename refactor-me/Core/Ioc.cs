using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web.Http.Dependencies;
using StructureMap;

namespace refactor_me.Core
{
	/// <summary>
	/// Ioc container, Handles the lifecyle of an Ioc
	/// Depends on Structure Map
	/// </summary>
	public class Ioc : IIoc
	{
		public IContainer Repo { get; }

		private readonly Action<ConfigurationExpression> _action;
		
		public Ioc(Action<ConfigurationExpression> action)
		{
			_action = action;
			Repo = new Container(_action);
		}

		public void Dispose()
		{
			
		}

		public object GetService(Type serviceType)
		{
			try
			{
				return Repo.GetInstance(serviceType);
			}
			catch(StructureMapConfigurationException)
			{
				return null;
			}
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			try
			{
				return Repo.GetAllInstances(serviceType).Cast<object>();
			}
			catch (StructureMapConfigurationException)
			{
				return new List<object>(); ;
			}
		}

		public IDependencyScope BeginScope()
		{
			return this;
		}
	}
}