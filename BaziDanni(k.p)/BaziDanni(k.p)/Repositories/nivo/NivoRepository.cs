using BaziDanni_k.p_.Repositories.Common;

namespace BaziDanni_k.p_.Repositories.nivo;

public sealed class NivoRepository(string cs) : GenericOracleRepository(cs, "nivo", "N_nivo", "N_nivo", "Ime_nivo", "Cvyat");
