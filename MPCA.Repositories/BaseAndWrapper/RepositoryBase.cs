#region Namespace
using Microsoft.EntityFrameworkCore;
using MPCA.Contracts;
using MPCA.Entities;
using System;
using System.Linq;
using System.Linq.Expressions; 
#endregion

namespace MPCA.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="MPCA.Contracts.IRepositoryBase{T}" />
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        #region Properties
        /// <summary>
        /// Gets or sets the repository context.
        /// </summary>
        /// <value>
        /// The repository context.
        /// </value>
        protected RepositoryContext RepositoryContext { get; set; } 
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{T}"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> FindAll()
        {
            return RepositoryContext.Set<T>().AsNoTracking();
        }

        /// <summary>
        /// Finds the by condition.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Determines whether the specified expression is exists.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>
        /// <c>true</c> if the specified expression is exists; otherwise, <c>false</c>.
        /// </returns>
        public bool IsExists(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().Count(expression) > 0;
        } 
        #endregion
    }
}
