﻿using System;
using System.Linq.Expressions;

namespace LinqSpecs
{
	public class OrSpecification<T> : Specification<T>
	{
		private readonly Specification<T> spec1;
		private readonly Specification<T> spec2;

		public OrSpecification(Specification<T> spec1, Specification<T> spec2)
		{
			this.spec1 = spec1;
			this.spec2 = spec2;
		}

		public override Expression<Func<T, bool>> IsSatisfiedBy()
		{
			ParameterExpression param = Expression.Parameter(typeof(T), "x");
			return spec1.IsSatisfiedBy().OrElse(spec2.IsSatisfiedBy());
		}

		public bool Equals(OrSpecification<T> other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Equals(other.spec1, spec1) && Equals(other.spec2, spec2);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof (OrSpecification<T>)) return false;
			return Equals((OrSpecification<T>) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((spec1 != null ? spec1.GetHashCode() : 0)*397) ^ (spec2 != null ? spec2.GetHashCode() : 0);
			}
		}
	}
}