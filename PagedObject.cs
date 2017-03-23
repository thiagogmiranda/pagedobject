using System;
using System.Linq;

namespace Miranda.PageTools
{
	public class PagedObject<T>
	{
		public int PageSize { get; set; }
		private int _numberOfElements;
		private int _numberOfPages;
		private int _index;
		public T[] Elements { get; private set; }

		public PagedObject(T[] array) : this (array, 100)
		{
		}

		public PagedObject(T[] array, int pageSize)
		{
			PageSize = pageSize;
			Elements = array;

			_numberOfElements = Elements.Length;

			_numberOfPages = _numberOfElements / PageSize;

			if ((_numberOfElements % PageSize) != 0)
			{
				_numberOfPages += 1;
			}
		}

		public void Iterate(Action<T[]> action)
		{
			for (int page = 0; page < _numberOfPages; page++)
			{
				_index = (page * PageSize);

				T[] elementsOfPage = Elements.Skip(_index).Take(PageSize).ToArray();

				action.Invoke(elementsOfPage);
			}
		}
	}
}
