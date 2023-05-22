package com.Sacral.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.Sacral.repository.AboutRepository;

@Service
public class AboutService {

    @Autowired
    AboutRepository aboutRepo;

    public String getIntroduction() {
        return aboutRepo.getIntroduction();
    }

    public String getGoals() {
        return aboutRepo.getGoals();
    }

    public void sendEmail(String email) {
        aboutRepo.sendEmail(email);
    }

}