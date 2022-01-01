using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using RazorTechnologies.TagHelpers.LayoutManager;

namespace RazorTechnologies.TagHelpers.DependencyResulotion
{
    public class LayoutManagerOptionsCollection : ILayoutManagerOptionsCollection
    {
        public int Count => _collection.Count;
        public IReadOnlyCollection<LayoutManagerOption> Collection => _collection;
        private readonly List<LayoutManagerOption> _collection = new() { };
        public bool AddOptions(LayoutManagerOption options)
        {
            if (options is null)
                throw new ArgumentNullException(nameof(options));

            if (_collection.Any(o => options == o))
                return false;

            _collection.Add(options);   
            return true;
        }
        public IEnumerator<LayoutManagerOption> GetEnumerator()
            => Collection.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()
            => Collection.GetEnumerator();

        public bool TryGetOptions(Guid key, out LayoutManagerOption options)
        {
            options = null;

            if (Collection is null)
                return false;
            options = _collection.FirstOrDefault(o => o.Key == key);

            if (options?.LayoutGeneratorOutput?.RuntimeLayoutGenerator is null|| options.LayoutGeneratorOutput.RuntimeLayoutGenerator.IsReadyToPresent)
                return false;

            return true;

        }
    }
}