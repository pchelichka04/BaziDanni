using BaziDanni_k.p_.Repositories.Common;

namespace BaziDanni_k.p_.Repositories.grupa;

public sealed class GrupaRepository(string cs) : GenericOracleRepository(cs, "grupa", "N_grupa", "N_grupa", "N_sport", "N_nivo", "N_trenior");
