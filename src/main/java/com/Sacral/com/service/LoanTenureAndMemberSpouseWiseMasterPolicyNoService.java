package com.Sacral.com.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.Sacral.com.repository.LoanTenureAndMemberSpouseWiseMasterPolicyNoRepository;

@Service
public class LoanTenureAndMemberSpouseWiseMasterPolicyNoService {

    @Autowired
    LoanTenureAndMemberSpouseWiseMasterPolicyNoRepository loanTenureAndMemberSpouseWiseMasterPolicyNoRepository;

    public List<LoanTenureAndMemberSpouseWiseMasterPolicyNo> findByTenure(String tenure){
        return loanTenureAndMemberSpouseWiseMasterPolicyNoRepository.findByTenure(tenure);
    }

    public List<LoanTenureAndMemberSpouseWiseMasterPolicyNo> findByMemberSpouseWiseMasterPolicyNo(String masterPolicyNo){
        return loanTenureAndMemberSpouseWiseMasterPolicyNoRepository.findByMemberSpouseWiseMasterPolicyNo(masterPolicyNo);
    }

}