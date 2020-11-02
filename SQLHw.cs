using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Linq;

namespace MinionsDB
{
    class Program
    {
        static string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Minions;Trusted_Connection=True";

        static void Main(string[] args)
        {
            //Task2();
            //Task3(2);
            //Task4("Svetlana", 21, "SF", "Jessie");
            //Task5(4);
            //Task6();

        }



        static void Task2()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            using (connection)
            {
                string selectionCommandString = "SELECT Villains.Name, COUNT(Minions.Name) FROM Villains " +
                                                "JOIN MinionsVillains ON Villains.Id = MinionsVillains.VillainId " +
                                                "JOIN Minions ON MinionsVillains.MinionId = Minions.Id " +
                                                "GROUP BY Villains.Id, Villains.Name " +
                                                "HAVING COUNT(Minions.Name) > 3 " +
                                                "ORDER BY COUNT(Minions.Name) DESC";

                SqlCommand command = new SqlCommand(selectionCommandString, connection);
                SqlDataReader reader = command.ExecuteReader();


                using (reader)
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write($"{reader[i]} ");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }



        static void Task3(int villainId)
        {
            //проверка на наличие злодея в базе
            string selectionVillainString = $"SELECT Villains.Name FROM Villains " +
                                             "WHERE Villains.Id = @villainId ";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand selectionVillain = new SqlCommand(selectionVillainString, connection);
            SqlParameter parameter = new SqlParameter("@villainId", SqlDbType.Int) { Value = villainId };
            selectionVillain.Parameters.Add(parameter);




            string selectionMinionsString = $"SELECT Minions.Name, Minions.Age FROM Minions " +
                                             "JOIN MinionsVillains ON Minions.Id = MinionsVillains.MinionId " +
                                             "JOIN Villains ON MinionsVillains.VillainId = Villains.Id " +
                                             "WHERE Villains.Id = @villainId " +
                                             "ORDER BY Minions.Name";

            SqlCommand selectionMinions = new SqlCommand(selectionMinionsString, connection);
            parameter = new SqlParameter("@villainId", SqlDbType.Int) { Value = villainId };
            selectionMinions.Parameters.Add(parameter);


            connection.Open();
            using (connection)
            {
                SqlDataReader reader1 = selectionVillain.ExecuteReader();

                using (reader1)
                {
                    while (reader1.Read())
                    {
                        for (int i = 0; i < reader1.FieldCount; i++)
                        {
                            Console.Write($"Villain: {reader1[i]} ");
                        }
                        Console.WriteLine();
                    }
                }



                SqlDataReader reader2 = selectionMinions.ExecuteReader();

                using (reader2)
                {
                    if (!reader2.Read())
                    {
                        Console.WriteLine("No villain with ID " + villainId + " exists in the database.");
                    }

                    int minionIndex = 0;

                    while (reader2.Read())
                    {

                        Console.Write(minionIndex + 1 + ". ");
                        for (int i = 0; i < reader2.FieldCount; i++)
                        {
                            Console.Write($"{reader2[i]} ");
                        }
                        Console.WriteLine();
                        minionIndex++;
                    }

                    if (minionIndex == 0)
                    {
                        Console.Write("(no minions)");
                    }
                }
            }
        }




        static void Task4(string minionName, int minionAge, string minionTown, string villainName)
        {
            SqlConnection connection = new SqlConnection(connectionString);


            //проверка на наличие города в базе
            string selectionTownString = $"SELECT Towns.Id FROM Towns " +
                                          "WHERE Towns.Name = @minionTown"; 

            SqlCommand selectionTown = new SqlCommand(selectionTownString, connection);
            SqlParameter parameter1 = new SqlParameter("@minionTown", SqlDbType.NVarChar, 50) { Value = minionTown };
            selectionTown.Parameters.Add(parameter1);



            //проверка на наличие злодея в базе
            string selectionVillainString = $"SELECT Villains.Id FROM Villains " +
                                             "WHERE Villains.Name = @villainName ";

            SqlCommand selectionVillain = new SqlCommand(selectionVillainString, connection);
            SqlParameter parameter2 = new SqlParameter("@villainName", SqlDbType.NVarChar, 50) { Value = villainName };
            selectionVillain.Parameters.Add(parameter2);




            connection.Open();
            using (connection)
            {
                SqlDataReader reader1 = selectionTown.ExecuteReader();

                using (reader1)
                {
                    if (!reader1.Read())
                    {
                        SqlConnection innerConnection = new SqlConnection(connectionString);
                        innerConnection.Open();
                        using (innerConnection)
                        {
                            SqlCommand insertionTown = new SqlCommand("INSERT INTO Towns " +
                                                                      "(Name) VALUES " +
                                                                      "(@minionTown)", innerConnection);

                            insertionTown.Parameters.AddWithValue("@minionTown", minionTown);

                            insertionTown.ExecuteNonQuery();

                            Console.WriteLine("Город " + minionTown + " был добавлен в базу данных.");
                        }
                    }
                }




                SqlDataReader reader2 = selectionVillain.ExecuteReader();

                using (reader2)
                {
                    if (!reader2.Read())
                    {
                        SqlConnection innerConnection = new SqlConnection(connectionString);
                        innerConnection.Open();
                        using (innerConnection)
                        {
                            SqlCommand insertionVillain = new SqlCommand("INSERT INTO Villains " +
                                                                         "(Name, EvilnessfactorId) VALUES " +
                                                                         "(@villainName, 4)", innerConnection);

                            insertionVillain.Parameters.AddWithValue("@villainName", villainName);

                            insertionVillain.ExecuteNonQuery();

                            Console.WriteLine("Злодей " + villainName + " был добавлен в базу данных.");
                        }
                    }
                }



                //добавление миньона в базу
                SqlCommand insertionMinion = new SqlCommand("INSERT INTO Minions " +
                                                            "(Name, Age, TownId) VALUES " +
                                                            "(@minionName, @minionAge, (SELECT Id FROM Towns WHERE Towns.Name = @minionTown))"
                                                            , connection);

                insertionMinion.Parameters.AddWithValue("@minionName", minionName);
                insertionMinion.Parameters.AddWithValue("@minionAge", minionAge);
                insertionMinion.Parameters.AddWithValue("@minionTown", minionTown);

                insertionMinion.ExecuteNonQuery();

                Console.WriteLine("Успешно добавлен " + minionName + ", чтобы быть миньоном " + villainName);



                //добавление связи между миньоном и злодеем в базу через таблицу MinionsVillains
                SqlCommand insertionRelation = new SqlCommand("INSERT INTO MinionsVillains " +
                                                              "(MinionId, VillainId) VALUES" +
                                                              "((SELECT Id FROM Minions WHERE Minions.Name = @minionName AND Minions.Age = @minionAge), " +
                                                              "(SELECT Id FROM Villains WHERE Villains.Name = @villainName))"
                                                              , connection);

                insertionRelation.Parameters.AddWithValue("@minionName", minionName);
                insertionRelation.Parameters.AddWithValue("@minionAge", minionAge);
                insertionRelation.Parameters.AddWithValue("@villainName", villainName);

                insertionRelation.ExecuteNonQuery();
            }
        }


        static void Task5(int villainId)
        {
            SqlConnection connection = new SqlConnection(connectionString);


            string selectionVillainString = $"SELECT Villains.Name FROM Villains " +
                                             "WHERE Villains.Id = @villainId ";

            SqlCommand selectionVillain = new SqlCommand(selectionVillainString, connection);
            SqlParameter parameter = new SqlParameter("@villainId", SqlDbType.Int) { Value = villainId };
            selectionVillain.Parameters.Add(parameter);



            string countMinionsString = $"SELECT COUNT(MinionId) FROM MinionsVillains " +
                                         "WHERE MinionsVillains.VillainId = @villainId";

            SqlCommand countMinions = new SqlCommand(countMinionsString, connection);
            parameter = new SqlParameter("@villainId", SqlDbType.Int) { Value = villainId };
            countMinions.Parameters.Add(parameter);



            string deletingRelationsString = "DELETE FROM MinionsVillains WHERE VillainId = @villainId";

            SqlCommand deletingRelations = new SqlCommand(deletingRelationsString, connection);
            parameter = new SqlParameter("@villainId", SqlDbType.Int) { Value = villainId };
            deletingRelations.Parameters.Add(parameter);



            string deletingVillainString = "DELETE FROM Villains WHERE Id = @villainId";

            SqlCommand deletingVillain = new SqlCommand(deletingVillainString, connection);
            parameter = new SqlParameter("@villainId", SqlDbType.Int) { Value = villainId };
            deletingVillain.Parameters.Add(parameter);


            connection.Open();
            using (connection)
            {
                SqlDataReader reader1 = selectionVillain.ExecuteReader();

                using (reader1)
                {
                    if (!reader1.Read())
                    {
                        Console.WriteLine("Такой злодей не найден.");
                    }

                    else
                    {
                        Console.WriteLine(reader1[0] + " был удалён.");
                    }
                    
                }

                SqlDataReader reader2 = countMinions.ExecuteReader();

                using (reader2)
                {
                    while (reader2.Read())
                    {
                        for (int i = 0; i < reader2.FieldCount; i++)
                        {
                            Console.Write($"{reader2[i]} миньонов было освобождено.");
                        }
                        Console.WriteLine();
                    }
                }

                deletingRelations.ExecuteNonQuery();

                deletingVillain.ExecuteNonQuery();
            }
            
        }



        static void Task6()
        {
            var minionsId = Console.ReadLine().Split().Select(int.Parse);
            
            foreach(int m in minionsId)
            {
                raiseAgeForOne(m);
            }

            static void raiseAgeForOne(int minionId)
            {
                SqlConnection connection = new SqlConnection(connectionString);


                string updatingAgeString = "UPDATE Minions SET Age = Age + 1" +
                                           "WHERE Id = @minionId";

                SqlCommand updatingAge = new SqlCommand(updatingAgeString, connection);
                SqlParameter parameter = new SqlParameter("@minionId", SqlDbType.Int) { Value = minionId };
                updatingAge.Parameters.Add(parameter);



                string selectionMinionsString = "SELECT Name, Age FROM Minions " +
                                                "WHERE Id = @minionId";

                SqlCommand selectionMinions = new SqlCommand(selectionMinionsString, connection);
                parameter = new SqlParameter("@minionId", SqlDbType.Int) { Value = minionId };
                selectionMinions.Parameters.Add(parameter);

                connection.Open();
                using(connection)
                {
                    updatingAge.ExecuteNonQuery();
                    SqlDataReader reader = selectionMinions.ExecuteReader();

                    using (reader)
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write($"{reader[i]} ");
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}
