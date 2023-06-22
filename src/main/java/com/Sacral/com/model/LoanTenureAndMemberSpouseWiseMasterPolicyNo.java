package com.Sacral.com.model;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;

@Entity
public class LoanTenureAndMemberSpouseWiseMasterPolicyNo {
	
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    private String tenure;
    private String memberSpouseWiseMasterPolicyNo;

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getTenure() {
        return tenure;
    }

    public void setTenure(String tenure) {
        this.tenure = tenure;
    }

    public String getMemberSpouseWiseMasterPolicyNo() {
        return memberSpouseWiseMasterPolicyNo;
    }

    public void setMemberSpouseWiseMasterPolicyNo(String memberSpouseWiseMasterPolicyNo) {
        this.memberSpouseWiseMasterPolicyNo = memberSpouseWiseMasterPolicyNo;
    }
}