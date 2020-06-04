using System.Collections.Generic;

namespace GA.LAED.Airbnb.Search
{
    /// <summary>
    /// Estrutura de dados da Tabela Hash para o Airbnb
    /// </summary>
    public class AirbnbHashTable
    {
        #region [ Properties ]

        /// <summary>
        /// Chave de busca
        /// </summary>
        private readonly int _key;

        /// <summary>
        /// Tamanho da tabela
        /// </summary>
        private readonly int _size;

        /// <summary>
        /// Tabela Hash com Listas Encadeadas
        /// </summary>
        private readonly List<Airbnb>[] _table;

        #endregion

        #region [ Constructor ]

        /// <summary>
        /// Construtor
        /// </summary>
        public AirbnbHashTable(int key, Airbnb[] array)
        {
            this._key = key;
            this._size = key;
            this._table = new List<Airbnb>[this._size];
        }

        #endregion

        #region [ Search ]

        /// <summary>
        /// Realiza a busca pela tabela Hash
        /// </summary>
        /// <param name="idRoom">Id Room</param>
        /// <param name="comparisons">Total de comparações</param>
        /// <returns>Objeto Airbnb</returns>
        public Airbnb Search(int idRoom, out int comparisons)
        {
            comparisons = 0;

            return null;
        }

        #endregion
    }
}