package com.Sacral.com.repository;

import org.springframework.data.jpa.repository.JpaRepository;

public interface LoanTenureAndMemberSpouseWiseMasterPolicyNoRepository extends JpaRepository<LoanTenureAndMemberSpouseWiseMasterPolicyNo, Long> {

    List<LoanTenureAndMemberSpouseWiseMasterPolicyNo> findByTenure(String tenure);
    List<LoanTenureAndMemberSpouseWiseMasterPolicyNo> findByMemberSpouseWiseMasterPolicyNo(String masterPolicyNo);

}