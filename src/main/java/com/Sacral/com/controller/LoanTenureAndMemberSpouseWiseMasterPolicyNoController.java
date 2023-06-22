package com.Sacral.com.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import com.Sacral.com.service.LoanTenureAndMemberSpouseWiseMasterPolicyNoService;
import com.Sacral.com.entity.LoanTenureAndMemberSpouseWiseMasterPolicyNo;

@RestController
public class LoanTenureAndMemberSpouseWiseMasterPolicyNoController {

    @Autowired
    LoanTenureAndMemberSpouseWiseMasterPolicyNoService loanTenureAndMemberSpouseWiseMasterPolicyNoService;

    @GetMapping("/loan/tenure")
    public List<LoanTenureAndMemberSpouseWiseMasterPolicyNo> findByTenure(@RequestParam("tenure") String tenure){
        return loanTenureAndMemberSpouseWiseMasterPolicyNoService.findByTenure(tenure);
    }

    @GetMapping("/loan/master-policy-no")
    public List<LoanTenureAndMemberSpouseWiseMasterPolicyNo> findByMemberSpouseWiseMasterPolicyNo(@RequestParam("masterPolicyNo") String masterPolicyNo){
        return loanTenureAndMemberSpouseWiseMasterPolicyNoService.findByMemberSpouseWiseMasterPolicyNo(masterPolicyNo);
    }

}