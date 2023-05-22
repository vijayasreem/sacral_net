package com.Sacral.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.Sacral.model.DPList;

@Repository
public interface DPListRepository extends JpaRepository<DPList, Long> {

    DPList findByFirstName(String firstName);
    DPList findByLastName(String lastName);
    DPList findByMiddleName(String middleName);
    DPList findByEmail(String email);
    DPList findByMobileNumber(String mobileNumber);
    DPList findByPhoneNumber(String phoneNumber);
    DPList findByPAN(String PAN);
    DPList findByAadhar(String Aadhar);
    DPList findByOtherID(String OtherID);
    DPList findByAction(String action);
    DPList findByUsername(String username);
    List<DPList> findByUsernameOrEmail(String username, String email);
    List<DPList> findAllByLimit(int limit);
    void saveDPList(DPList dpList);
    void editDPList(DPList dpList);
    void deleteDPList(DPList dpList);
}