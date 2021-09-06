using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using castles.Models;

namespace castles.Repositories
{
  public class CastlesRepository
  {
    private readonly IDbConnection _db;

    public CastlesRepository(IDbConnection db)
    {
      _db = db;
    }
    internal List<Castle> Get()
    {
      string sql = "SELECT * FROM castles";
      return _db.Query<Castle>(sql).ToList();
    }

    internal Castle Get(int id)
    {
      string sql = "SELECT * FROM castles WHERE id = @id";
      return _db.QueryFirstOrDefault<Castle>(sql, new { id });
    }
    internal Castle Create(Castle newCastle)
    {
      string sql = @"
      INSERT INTO castles
      (name, builtYear, destroyed)
      VALUES
      (@Name, @BuiltYear, @Destroyed);
      SELECT LAST_INSERT_ID();";
      newCastle.Id = _db.ExecuteScalar<int>(sql, newCastle);
      return newCastle;
    }
    internal Castle Update(Castle updatedCastle)
    {
      string sql = @"
        UPDATE castles
        SET
            name = @Name,
            builtYear = @BuiltYear,
            destroyed = @Destroyed
        WHERE id = @Id;
      ";
      _db.Execute(sql, updatedCastle);
      return updatedCastle;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM castles WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}