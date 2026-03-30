using BaziDanni_k.p_.Repositories.Common;

namespace BaziDanni_k.p_.Repositories.den_sedmica;

public sealed class DenSedmicaRepository(string cs) : GenericOracleRepository(cs, "den_sedmica", "N_den", "N_den", "Den", "Cvyat");
