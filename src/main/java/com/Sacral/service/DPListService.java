package com.Sacral.service;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.Sacral.model.DPList;
import com.Sacral.repository.DPListRepository;

@Service
public class DPListService {

    @Autowired
    DPListRepository dpListRepository;

    public DPList findByFirstName(String firstName) {
        return dpListRepository.findByFirstName(firstName);
    }

    public DPList findByLastName(String lastName) {
        return dpListRepository.findByLastName(lastName);
    }

    public DPList findByMiddleName(String middleName) {
        return dpListRepository.findByMiddleName(middleName);
    }

    public DPList findByEmail(String email) {
        return dpListRepository.findByEmail(email);
    }

    public DPList findByMobileNumber(String mobileNumber) {
        return dpListRepository.findByMobileNumber(mobileNumber);
    }

    public DPList findByPhoneNumber(String phoneNumber) {
        return dpListRepository.findByPhoneNumber(phoneNumber);
    }

    public DPList findByPAN(String PAN) {
        return dpListRepository.findByPAN(PAN);
    }

    public DPList findByAadhar(String Aadhar) {
        return dpListRepository.findByAadhar(Aadhar);
    }

    public DPList findByOtherID(String OtherID) {
        return dpListRepository.findByOtherID(OtherID);
    }

    public DPList findByAction(String action) {
        return dpListRepository.findByAction(action);
    }

    public DPList findByUsername(String username) {
        return dpListRepository.findByUsername(username);
    }

    public List<DPList> findByUsernameOrEmail(String username, String email) {
        return dpListRepository.findByUsernameOrEmail(username, email);
    }

    public List<DPList> findAllByLimit(int limit) {
        return dpListRepository.findAllByLimit(limit);
    }

    public void saveDPList(DPList dpList) {
        dpListRepository.save(dpList);
    }

    public void editDPList(DPList dpList) {
        dpListRepository.save(dpList);
    }

    public void deleteDPList(DPList dpList) {
        dpListRepository.delete(dpList);
    }
}