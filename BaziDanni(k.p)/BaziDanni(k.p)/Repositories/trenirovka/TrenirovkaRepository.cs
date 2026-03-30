using BaziDanni_k.p_.Repositories.Common;

namespace BaziDanni_k.p_.Repositories.trenirovka;

public sealed class TrenirovkaRepository(string cs) : GenericOracleRepository(cs, "trenirovka", "N_grupa", "N_grupa", "datata", "chas", "N_chlen", "N_den");
