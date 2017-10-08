using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using StructureMap;

namespace refactor_me.Core
{
	public interface IIoc : IDependencyResolver
	{
		IContainer Repo { get; }
	}
}