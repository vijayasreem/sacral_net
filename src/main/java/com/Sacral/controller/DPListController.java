package com.Sacral.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.Sacral.model.DPList;
import com.Sacral.service.DPListService;

@RestController
@RequestMapping("/dplist")
public class DPListController {

	@Autowired
	DPListService dpListService;

	@GetMapping("/{firstName}")
	public DPList findByFirstName(@PathVariable String firstName) {
		return dpListService.findByFirstName(firstName);
	}

	@GetMapping("/{lastName}")
	public DPList findByLastName(@PathVariable String lastName) {
		return dpListService.findByLastName(lastName);
	}

	@GetMapping("/{middleName}")
	public DPList findByMiddleName(@PathVariable String middleName) {
		return dpListService.findByMiddleName(middleName);
	}

	@GetMapping("/{email}")
	public DPList findByEmail(@PathVariable String email) {
		return dpListService.findByEmail(email);
	}

	@GetMapping("/{mobileNumber}")
	public DPList findByMobileNumber(@PathVariable String mobileNumber) {
		return dpListService.findByMobileNumber(mobileNumber);
	}

	@GetMapping("/{phoneNumber}")
	public DPList findByPhoneNumber(@PathVariable String phoneNumber) {
		return dpListService.findByPhoneNumber(phoneNumber);
	}

	@GetMapping("/{PAN}")
	public DPList findByPAN(@PathVariable String PAN) {
		return dpListService.findByPAN(PAN);
	}

	@GetMapping("/{Aadhar}")
	public DPList findByAadhar(@PathVariable String Aadhar) {
		return dpListService.findByAadhar(Aadhar);
	}

	@GetMapping("/{OtherID}")
	public DPList findByOtherID(@PathVariable String OtherID) {
		return dpListService.findByOtherID(OtherID);
	}

	@GetMapping("/{action}")
	public DPList findByAction(@PathVariable String action) {
		return dpListService.findByAction(action);
	}

	@GetMapping("/{username}")
	public DPList findByUsername(@PathVariable String username) {
		return dpListService.findByUsername(username);
	}

	@PostMapping("/limit")
	public List<DPList> findByUsernameOrEmail(@RequestBody DPList dpList) {
		return dpListService.findByUsernameOrEmail(dpList.getUsername(), dpList.getEmail());
	}

	@PostMapping("/limit/{limit}")
	public List<DPList> findAllByLimit(@PathVariable int limit) {
		return dpListService.findAllByLimit(limit);
	}

	@PostMapping
	public void saveDPList(@RequestBody DPList dpList) {
		dpListService.saveDPList(dpList);
	}

	@PutMapping
	public void editDPList(@RequestBody DPList dpList) {
		dpListService.editDPList(dpList);
	}

	@DeleteMapping
	public void