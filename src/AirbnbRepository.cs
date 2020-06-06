using System;
using System.IO;

namespace GA.LAED.Airbnb.Search
{
    /// <summary>
    /// Repositório de dados do Airbnb
    /// </summary>
    public class AirbnbRepository
    {
        #region [ Constants ]

        /// <summary>
        /// Caminho do arquivo
        /// </summary>
        private const string FILE_PATH = @"Files/data_airbnb.txt";

        /// <summary>
        /// Chave da tabela Hash
        /// </summary>
        private const int HASH_KEY = 523;

        #endregion

        #region [ Data ]

        /// <summary>
        /// Array de Airbnb
        /// </summary>
        private readonly Airbnb[] _arrayData;

        /// <summary>
        /// Array ordenado de Airbnb
        /// </summary>
        private readonly AirbnbBinary _binaryData;

        /// <summary>
        /// Arvóre Binária de Airbnb
        /// </summary>
        private readonly AirbnbBinaryTree _binaryTreeData;

        /// <summary>
        /// Hash Table de Airbnb
        /// </summary>
        private readonly AirbnbHashTable _hashTableData;

        #endregion

        #region [ Constructor ]

        /// <summary>
        /// Construtor
        /// </summary>
        public AirbnbRepository()
        {
            // Obtêm os dados armazenados no arquivo
            this._arrayData = this.ReadFile(FILE_PATH);
            // Obtêm o tipo de dado para a pesquisa binária
            this._binaryData = new AirbnbBinary(this._arrayData);
            // Obtêm o tipo de dado de Árvore Binária
            this._binaryTreeData = new AirbnbBinaryTree(this._arrayData);
            // Obtêm o tipo de dado de Tabela Hash
            this._hashTableData = new AirbnbHashTable(HASH_KEY, this._arrayData);
        }

        #endregion

        #region [ Searchs ]

        /// <summary>
        /// Obtêm o Airbnb pelo IdRoom utilizando pesquisa Sequencial
        /// </summary>
        /// <param name="idRoom">Id Room</param>
        /// <param name="comparisons">Total de comparações</param>
        /// <returns>Objeto Airbnb</returns>
        public Airbnb SequentialSearch(int idRoom, out int comparisons)
        {
            comparisons = 0;
            for (int i = 0; i < this._arrayData.Length; i++)
            {
                comparisons++;
                if (this._arrayData[i].RoomId == idRoom)
                    return this._arrayData[i];
            }
            return null;
        }

        /// <summary>
        /// Obtêm o Airbnb pelo IdRoom utilizando pesquisa Binária
        /// </summary>
        /// <param name="idRoom">Id Room</param>
        /// <param name="comparisons">Total de comparações</param>
        /// <returns>Objeto Airbnb</returns>
        public Airbnb BinarySearch(int idRoom, out int comparisons)
        {
            return this._binaryData.Search(idRoom, out comparisons);
        }

        /// <summary>
        /// Obtêm o Airbnb pelo IdRoom utilizando pesquisa com Árvore Binária
        /// </summary>
        /// <param name="idRoom">Id Room</param>
        /// <param name="comparisons">Total de comparações</param>
        /// <returns>Objeto Airbnb</returns>
        public Airbnb BinaryTreeSearch(int idRoom, out int comparisons)
        {
            return this._binaryTreeData.Search(idRoom, out comparisons);
        }

        /// <summary>
        /// Obtêm o Airbnb pelo IdRoom utilizando pesquisa com Tabela Hash
        /// </summary>
        /// <param name="idRoom">Id Room</param>
        /// <param name="comparisons">Total de comparações</param>
        /// <returns>Objeto Airbnb</returns>
        public Airbnb HashTableSearch(int idRoom, out int comparisons)
        {
            return this._hashTableData.Search(idRoom, out comparisons);
        }

        /// <summary>
        /// Obtêm o tamanho do array
        /// </summary>
        /// <returns>Tamanho do array</returns>
        public int GetCount()
        {
            return this._arrayData.Length;
        }

        #endregion

        #region [ Read File ]

        /// <summary>
        /// Lê os dados Airbnb armazenados no arquivo texto
        /// </summary>
        /// <param name="path">Caminho do arquivo</param>
        /// <returns>Array de Airbnb</returns>
        private Airbnb[] ReadFile(string path)
        {
            // Le todas as linhas do arquivo
            string[] lines = File.ReadAllLines(path);
            // Define o arrary ignorando a primeira posição
            Airbnb[] airbnbs = new Airbnb[lines.Length - 1];

            for (int i = 1; i < lines.Length; i++)
            {
                string[] line = lines[i].Split("\t");
                int roomId = Convert.ToInt32(line[0]);
                int hostId = Convert.ToInt32(line[1]);
                string roomType = line[2];
                string country = line[3];
                string city = line[4];
                string neighborhood = line[5];
                double review = Convert.ToDouble(line[6]);
                double overallSatisfaction = Convert.ToDouble(line[7]);
                double accommodates = Convert.ToDouble(line[8]);
                double bedrooms = Convert.ToDouble(line[9]);
                double price = Convert.ToDouble(line[10]);
                string propertyType = line[11];

                airbnbs[i - 1] = new Airbnb(roomId,
                                            hostId,
                                            roomType,
                                            city,
                                            country,
                                            neighborhood,
                                            review,
                                            overallSatisfaction,
                                            accommodates,
                                            bedrooms,
                                            price,
                                            propertyType);
            }

            return airbnbs;
        }

        #endregion
    }
}